
"use strict";
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    document.getElementById("sendButton").disabled = true;

    connection.on("LoadMessages", function () {
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
        var date = new Date();
        var dateStr =
            ("00" + (date.getMonth() + 1)).slice(-2) + "/" +
            ("00" + date.getDate()).slice(-2) + "/" +
            date.getFullYear() + " " +
            ("00" + date.getHours()).slice(-2) + ":" +
            ("00" + date.getMinutes()).slice(-2) + ":" +
            ("00" + date.getSeconds()).slice(-2);
            $.ajax({
                url: '/Home/Index',
                method: 'POST',
                data: {
                    TextMessage: message,
                }
            })
        var divMessage = document.createElement("div");
        divMessage.className = "content chat-message-left pb-4";

        var divButtonsContainer = document.createElement("div");
        divButtonsContainer.className = "hide buttons-container";
        divButtonsContainer.ariaRoleDescription = "group";
        divButtonsContainer.ariaLabel = "Дії з повідомленнями";

        var divButtonsGroup = document.createElement("div");
        divButtonsGroup.className = "d-flex justify-content-end";

        var deleteButton = document.createElement("input");
        deleteButton.type = "button";
        deleteButton.className = "button";
        deleteButton.ariaLabel = "Видалити";
        deleteButton.value = "&timesb;";

        var editButton = document.createElement("input");
        editButton.type = "button";
        editButton.className = "button";
        editButton.ariaLabel = "Редагувати";
        editButton.value = "ED";

        var answerButton = document.createElement("input");
        answerButton.type = "button";
        answerButton.className = "button";
        answerButton.ariaLabel = "Відповісти";
        answerButton.value = "&#64;";

        var divBlock = document.createElement("div");
        divBlock.className = "flex-shrink-1 bg-light rounded py-2 px-3 ml-3";

        var divName = document.createElement("div");
        divName.className = "font-weight-bold mb-1 fw-bold";
        divName.textContent = user;

        var divText = document.createElement("div");
        divText.textContent = message;

        var divDate = document.createElement("div");
        divDate.className = "d-flex flex-row justify-content-end p-1";
        
        divDate.textContent = dateStr;

        divBlock.appendChild(divName);
        divBlock.appendChild(document.createElement("p"));
        divBlock.appendChild(divText);
        divMessage.appendChild(divBlock);
        divMessage.appendChild(divDate);
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
                        `<div class="content chat-message-left pb-4">
                    <div class="hide buttons-container" role="group" aria-label="Дії з повідомленнями">
        <div class="d-flex  justify-content-end">
            <input  type="button" class="button" aria-label="Видалити"   value=&timesb; role="button" tabindex="0"></input>
            <input  type="button" class="button" aria-label="Редагувати" value="ED"     role="button" tabindex="0"></input>
            <input  type="button" class="button" aria-label="Відповисти" value=&#64;    role="button" tabindex="0"></input>
        </div>
    </div>
                     <div class="flex-shrink-1 bg-light rounded py-2 px-3 ml-3">
                            <div class="font-weight-bold fw-bold mb-1">${v.User.UserName}</div><p>
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
//document.querySelector('#chat').lastElementChild.scrollIntoView();