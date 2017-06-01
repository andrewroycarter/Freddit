namespace Freddit

open System
open Foundation
open UIKit

type PostsTableViewDataSource () =
    inherit UITableViewDataSource ()

    let posts = [{Post.title="Test reddit post"}]

    override this.RowsInSection (tableView, section) =
        nint posts.Length

    override this.GetCell (tableView, indexPath) =
        let cell = tableView.DequeueReusableCell ("PostTableViewCell", indexPath) :?> PostTableViewCell
        cell.TitleLabel.Text <- (posts.Item indexPath.Row).title
        cell :> UITableViewCell
