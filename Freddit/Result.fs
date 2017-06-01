namespace Freddit

open System

module Result =

    type Result<'TSuccess, 'TError> =
        | Ok of 'TSuccess
        | Error of 'TError

    let Map transform input = match input with Error e -> Error e | Ok x -> Ok (transform x)

    let MapError transform input = match input with Error e -> Error (transform e) | Ok x -> Ok x

    let Bind transform input = match input with Error e -> Error e | Ok x -> transform x
