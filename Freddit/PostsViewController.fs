namespace Freddit

open System
open Foundation
open UIKit
open Result

[<Register ("PostsViewController")>]
type PostsViewController (handle:IntPtr) as this =
    inherit UIViewController (handle)
    do
        this.NavigationItem.Title <- "Frontpage"

    let tableViewDelegate = new PostsTableViewDelegate ()
    let tableViewDataSource = new PostsTableViewDataSource ()

    [<Outlet>]
    member val TableView = null :> UITableView with get, set

    override this.ViewDidLoad () =
        base.ViewDidLoad ()
        this.setupTableView

    override this.ViewDidAppear (animated:bool) =
        base.ViewDidAppear (animated)
        this.GetPosts |> ignore

    member private this.setupTableView =
        let nib = UINib.FromName ("PostTableViewCell", null)
        this.TableView.RegisterNibForCellReuse (nib, "PostTableViewCell")
        this.TableView.Delegate <- tableViewDelegate
        this.TableView.DataSource <- tableViewDataSource
    
    member private this.GetPosts =
        async {
            let httpClient = new System.Net.Http.HttpClient ()
            let uri = Uri "http://www.reddit.com/.json"
            let! response = httpClient.GetAsync (uri) |> Async.AwaitTask
            let! responseString = response.Content.ReadAsStringAsync () |> Async.AwaitTask
            return Ok responseString
        }

