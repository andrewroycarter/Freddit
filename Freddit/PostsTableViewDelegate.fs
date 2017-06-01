namespace Freddit

open System
open Foundation
open UIKit

type PostsTableViewDelegate () =
    inherit UITableViewDelegate ()

    override this.RowSelected (tableView, indexPath) =
        tableView.DeselectRow (indexPath, true)
