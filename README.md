# websocket game boilerplate

* server
	* .Net core
	* [websocket-sharp](https://github.com/sta/websocket-sharp)
	
* client
	* Unity3D
	* [Simple Web Sockets for Unity WebGL](https://assetstore.unity.com/packages/essentials/tutorial-projects/simple-web-sockets-for-unity-webgl-38367)
	* [websocket-sharp](https://github.com/sta/websocket-sharp)
	
## note
### two websocket library in client

In webgl platform, use `simple web socket for unity webgl` to support webgl.
In other platforms, use `websocket-sharp].


## build

build shared library, copy dll to client

```bash
cd GameLib
dotnet build --output ../GameClient/Assets/GameLib
```

run server
```bash
cd GameServer
dotnet run
```

run unity game
