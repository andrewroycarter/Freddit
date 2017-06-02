namespace Freddit

open System
open Foundation
open UIKit

type PostsTableViewDelegateRowSelectionDelegate = delegate of tableView:UITableView * row:NSIndexPath -> unit

type PostsTableViewDelegate () =
    inherit UITableViewDelegate ()

    member val RowSelectionDelegate = Option<PostsTableViewDelegateRowSelectionDelegate>.None with get, set

    override this.RowSelected (tableView, indexPath) =
        this.RowSelectionDelegate |> Option.iter (fun d -> d.Invoke (tableView, indexPath))
        tableView.DeselectRow (indexPath, true)
