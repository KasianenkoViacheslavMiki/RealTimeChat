
"use strict";
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    document.getElementById("sendButton").disabled = true;

    connection.on("LoadMessages", function (_roomId) {
        LoadMessages(_roomId);
    });
    connection.on("ReceiveMessage", function (user, message, _idRoom, _idUser) {
        AddMessages(user, message, _idRoom, _idUser);
    });

    


    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });
   

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = "Miki";
        var message = document.getElementById("messageInput").value;
        var idUser = "1"
        var idRoom = document.getElementById("idRoom").value;
        //var message = typeMessage();
        //message.TextMessage = document.getElementById("messageInput").value;
        //message.UserName = "Miki";
        //message.IdUser = 1;
        //message.IdRoom = document.getElementById("idRoom").value;
        $.ajax({
                url: '/Home/SendMessage',
                method: 'POST',
                data: {
                    TextMessage: message,
                    UserId: idUser,
                    RoomId: idRoom,
                }
        })
        connection.invoke("SendMessageServer",user,message,3,1).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
})
LoadMessages(document.getElementById("idRoom").value);
//document.querySelector('#chat').lastElementChild.scrollIntoView();

