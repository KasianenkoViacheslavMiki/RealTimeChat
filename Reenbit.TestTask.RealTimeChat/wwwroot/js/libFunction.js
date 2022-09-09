﻿

function AddMessages(user, message, _idRoom, _idUser) {
    var date = new Date();
    var dateStr =
        ("00" + (date.getMonth() + 1)).slice(-2) + "/" +
        ("00" + date.getDate()).slice(-2) + "/" +
        date.getFullYear() + " " +
        ("00" + date.getHours()).slice(-2) + ":" +
        ("00" + date.getMinutes()).slice(-2) + ":" +
        ("00" + date.getSeconds()).slice(-2);

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
    deleteButton.value = "✖";

    var editButton = document.createElement("input");
    editButton.type = "button";
    editButton.className = "button";
    editButton.ariaLabel = "Редагувати";
    editButton.value = "ED";

    var answerButton = document.createElement("input");
    answerButton.type = "button";
    answerButton.className = "button";
    answerButton.ariaLabel = "Відповісти";
    answerButton.value = "@";

    divButtonsGroup.appendChild(deleteButton);
    divButtonsGroup.appendChild(editButton);
    divButtonsGroup.appendChild(answerButton);
    divButtonsContainer.appendChild(divButtonsGroup);

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

    divMessage.appendChild(divButtonsContainer);
    divMessage.appendChild(divBlock);
    divMessage.appendChild(divDate);
    document.querySelector('#chat').appendChild(divMessage);
    document.querySelector('#chat').lastElementChild.scrollIntoView();
}

function LoadMessages(_idRoom) {
    var tr = '';
    $.ajax({
        url: '/Home/GetMessagesRoomChat',
        method: 'POST',
        data: {
            IdRoom: _idRoom
        },
        success: (result) => {
            $.each(result, (k, v) => {
                tr = tr +
                    `<div id= "id=${v.Id}" class="content chat-message-left pb-4">
                    <input  runat="server" value="${v.Id}" type="hidden"></input>
                    <div class="hide buttons-container" role="group" aria-label="Дії з повідомленнями">
        <div class="d-flex  justify-content-end">
            <input  type="button" class="button" aria-label="Видалити"   value=&#x2716; role="button" tabindex="0"></input>
            <input  type="button" class="button" aria-label="Редагувати" value="ED"     role="button" tabindex="0"></input>
            <input  type="button" class="button" aria-label="Відповисти" value=&#64;    role="button" tabindex="0"></input>
        </div>
    </div>
                     <div class="flex-shrink-1 bg-light rounded py-2 px-3 ml-3">
                           <input  runat="server" value="${v.UserId}" type="hidden"></input> 
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
function typeMessage() {
    var typeMessage = Object.create({},
        {
            TextMessage: {
                writable: true,
                configurable: true,
                value: ""
            },
            UserName: {
                writable: true,
                configurable: true,
                value: ""
            },
            IdUser: {
                writable: true,
                configurable: true,
                value: 0
            },
            IdRoom: {
                writable: true,
                configurable: true,
                value: 0
            }
        }
    );
    return typeMessage;
}