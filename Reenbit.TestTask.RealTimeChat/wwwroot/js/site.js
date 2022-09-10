
"use strict";
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    document.getElementById("sendButton").disabled = true;
    connection.on("ReceiveMessage", function (MessageId, MessagesUserID, UserName, MessageText, MessageDate) {
        $.ajax({
            url: '/Home/GetUserId',
            type: 'POST',
            async: true
            ,
            success: (UserId) => {
                OverWriteAddMessages(MessageId, MessagesUserID, UserName, MessageText, MessageDate,UserId)
            }
        })
    });

    


    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });
   

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var message = document.getElementById("messageInput").value;
        var idRoom = document.getElementById("chatId").value;
        //var message = typeMessage();
        //message.TextMessage = document.getElementById("messageInput").value;
        //message.UserName = "Miki";
        //message.IdUser = 1;
        //message.IdRoom = document.getElementById("idRoom").value;
        $.ajax({
            url: '/Home/SendMessage',
            type: 'POST',
            data: {
                TextMessage: message,
                RoomId: idRoom
            },
            async: true
        });
        //connection.invoke("SendMessageServer", user, message/*, idRoom, idUser*/).catch(function (err) {
        //    return console.error(err.toString());
        //});
        event.preventDefault();
    });
})
/*LoadMessages(3);*/
//document.querySelector('#chat').lastElementChild.scrollIntoView();

