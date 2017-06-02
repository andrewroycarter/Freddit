namespace Freddit

open FSharp.Data
open System
open Foundation
open UIKit
open SafariServices
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

    member this.PostSelected (tableView:UITableView) (indexPath:NSIndexPath) =
        let post = tableViewDataSource.Posts.[indexPath.Row]
        let url = NSUrl.FromString post.Data.Url
        let controller = new SFSafariViewController (url)
        this.NavigationController.PushViewController (controller, true)

    override this.ViewDidLoad () =
        base.ViewDidLoad ()
        this.setupTableView
        tableViewDelegate.RowSelectionDelegate <- Some <| PostsTableViewDelegateRowSelectionDelegate this.PostSelected

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
