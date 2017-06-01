namespace Freddit

open System
open Foundation
open UIKit

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

    member private this.setupTableView =
        let nib = UINib.FromName ("PostTableViewCell", null)
        this.TableView.RegisterNibForCellReuse (nib, "PostTableViewCell")
        this.TableView.Delegate <- tableViewDelegate
        this.TableView.DataSource <- tableViewDataSource
