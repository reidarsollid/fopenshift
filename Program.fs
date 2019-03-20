// Learn more about F# at http://fsharp.org

open Giraffe
open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

let routes =
    choose [
        route "/" >=> text "Hello World from F# dotnetcore"
    ]

let configureApp(app: IApplicationBuilder) =
    app.UseGiraffe routes
    
let configureServices(services: IServiceCollection) =
    services.AddGiraffe() |> ignore
 
[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0 // return an integer exit code
