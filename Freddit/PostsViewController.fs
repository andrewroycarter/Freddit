namespace Freddit

open FSharp.Data
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

    let postSelected (tableView:UITableView) (indexPath:NSIndexPath) =
        printfn "selected"

    [<Outlet>]
    member val TableView = null :> UITableView with get, set

    override this.ViewDidLoad () =
        base.ViewDidLoad ()
        this.setupTableView
        tableViewDelegate.RowSelectionDelegate <- Some <| PostsTableViewDelegateRowSelectionDelegate postSelected

    override this.ViewDidAppear (animated:bool) =
        base.ViewDidAppear (animated)
        this.GetPosts |> Async.StartImmediate

    member private this.setupTableView =
        let nib = UINib.FromName ("PostTableViewCell", null)
        this.TableView.RegisterNibForCellReuse (nib, "PostTableViewCell")
        this.TableView.WeakDelegate <- tableViewDelegate
        this.TableView.WeakDataSource <- tableViewDataSource
    
    member private this.GetPosts =
        async {
            let! page = RedditPage.AsyncLoad("http://www.reddit.com/.json")
            tableViewDataSource.Posts <- page.Data.Children
            this.TableView.ReloadData ()
        }
