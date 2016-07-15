/**
 * Created by xjsaber on 2016/4/28.
 */
var socket = (function(){
	var my = {};
    //var address = "ws://192.168.15.177:8080";
    var ws;
    my.connect = function (name) {
    	
    	address = 'ws://127.0.0.1:8080'; 
   		ws = new WebSocket(address);
  	  	
        ws.onopen = function (e) {
            var msg = "Server > connection open.";
            ws.send('{<' + name + '>}');
            console.log(msg);
        };
        ws.onmessage=function(e){
            var msg = e.data
            console.log(msg);
        };
        ws.onerror=function(e){
            var msg = 'Server > '+e.data;
            console.log(msg);
        };
        ws.onclose=function(e){
            var msg = "Server > connection closed by server.";
            console.log(msg)
        };
    };
    my.quit = function () {
        if (ws){
            ws.close();
            ws=null;
            var msg='Server > connection closed.';
            console.log(msg);
        }
    }
    my.send = function (to, msg) {
        ws.send(to+'{0}'+msg);
    }

    return my;
})();