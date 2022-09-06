
"use strict";
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    document.getElementById("sendButton").disabled = true;

    connection.on("LoadMessages", function (user, message) {
        LoadMessages();
    });
    connection.on("ReceiveMessage", function (user, message) {
        AddMessages(message, user);
    });
    LoadMessages();
 


    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = "Miki";
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });





    function AddMessages(message, user) {
        var divMessage = document.createElement("div");
        divMessage.className = "chat-message-left pb-4";

        var divBlock = document.createElement("div");
        divBlock.className = "flex-shrink-1 bg-light rounded py-2 px-3 ml-3";

        var divText = document.createElement("div");
        divText.textContent = message;

        var divName = document.createElement("div");
        divName.className = "font-weight-bold mb-1";
        divName.textContent = user;

        divBlock.appendChild(divName);
        divBlock.appendChild(divText);
        divMessage.appendChild(divBlock);
        document.querySelector('#chat').appendChild(divMessage);
        document.querySelector('#chat').lastElementChild.scrollIntoView();
    }

    function LoadMessages() {
        var tr = '';
        $.ajax({
            url: '/Home/GetMessagesChat',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr = tr +
                        `<div class="chat-message-left pb-4">
                    
                     <div class="flex-shrink-1 bg-light rounded py-2 px-3 ml-3">
                            <div class="font-weight-bold mb-1"><b>${v.User.UserName}</b></div><p>
                        <div>${v.TextMessage} </div>
                    </div>
                        <div class="d-flex flex-row justify-content-end p-1">
                             <p>${v.DateMessage})</p>
                        </div>
                   </div>
                    `;
                });

                $("#chat").html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        });
        
    }
})
document.querySelector('#chat').lastElementChild.scrollIntoView();