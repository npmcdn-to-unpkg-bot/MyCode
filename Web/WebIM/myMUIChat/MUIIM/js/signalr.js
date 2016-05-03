/**
 * Created by xjsaber on 2016/5/1.
 */
var signalr = (function(){
	var my = {};

	var connection = $.connection('"/tlm'), //$.connection.hub,
        hub = $.connection.hub;

    connection.logging = true;

    // hub.client.message = function (value) {
    // }

    connection.start()
        .done(function () {
            writeLine("connected");
        })
        .fail(function (error) {
            writeError(value);
        });
    
	my.connection = connection;
	my.hub = hub;
	return my;
//  $("#sendToMe").click(function () {
//      hub.server.sendToMe(message.val());
//  });
//
//  $("#sendToUser").click(function () {
//      hub.server.sendToUser(userId.val(), message.val());
//  });
})();
