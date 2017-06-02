namespace Freddit

open System
open Foundation
open UIKit
open Result

type PostsTableViewDataSource () =
    inherit UITableViewDataSource ()

    member val Posts : RedditPage.Child[] = Array.empty with get, set

    override this.RowsInSection (tableView, section) =
        nint this.Posts.Length

    override this.GetCell (tableView, indexPath) =
        let cell = tableView.DequeueReusableCell ("PostTableViewCell", indexPath) :?> PostTableViewCell
        cell.TitleLabel.Text <- this.Posts.[indexPath.Row].Data.Title
        cell :> UITableViewCell
