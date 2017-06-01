namespace Freddit

open System
open Foundation
open UIKit

type PostsTableViewDataSource () =
    inherit UITableViewDataSource ()

    let posts = [1; 2; 3]

    override this.RowsInSection (tableView, section) =
        nint posts.Length

    override this.GetCell (tableView, indexPath) =
        let cell = tableView.DequeueReusableCell ("PostTableViewCell", indexPath) :?> PostTableViewCell
        cell.TitleLabel.Text <- sprintf "%i" indexPath.Row
        cell :> UITableViewCell
