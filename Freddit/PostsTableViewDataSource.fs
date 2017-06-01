namespace Freddit

open System
open Foundation
open UIKit
open Result

type PostsTableViewDataSource () =
    inherit UITableViewDataSource ()
   
    member val Posts = [{Post.title="Test reddit post"}]

    override this.RowsInSection (tableView, section) =
        nint this.Posts.Length

    override this.GetCell (tableView, indexPath) =
        let cell = tableView.DequeueReusableCell ("PostTableViewCell", indexPath) :?> PostTableViewCell
        cell.TitleLabel.Text <- (this.Posts.Item indexPath.Row).title
        cell :> UITableViewCell
