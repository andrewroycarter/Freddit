namespace Freddit

open System
open Foundation
open UIKit

[<Register ("PostTableViewCell")>]
type PostTableViewCell (handle:IntPtr) =
    inherit UITableViewCell (handle)
  
    [<Outlet>]
    member val TitleLabel = null :> UILabel with get, set
