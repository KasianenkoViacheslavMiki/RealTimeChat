function OverWriteAddMessages(MessageId, UserID, UserName, MessageText, MessageDate, SessionUserID, RoomID) {
    var date = new Date();
    var dateStr =
        ("00" + date.getDate()).slice(-2) + "." +
        ("00" + (date.getMonth() + 1)).slice(-2) + "." +
        date.getFullYear() + " " +
        ("00" + date.getHours()).slice(-2) + ":" +
        ("00" + date.getMinutes()).slice(-2) + ":" +
        ("00" + date.getSeconds()).slice(-2);
    var container = document.createElement("div");
    container.id = 'message-' + MessageId;
    container.setAttribute("value", MessageId);
    container.className = 'content chat-message-left pb-4';

    var hiddenInput = document.createElement("input"); 
    hiddenInput.value = MessageId;
    hiddenInput.type = "hidden";

    var containerButtons = document.createElement("div");
    containerButtons.className = 'hide buttons-container';
    containerButtons.ariaRoleDescription = "group";
    containerButtons.ariaLabel = "Дії з повідомленнями";

    var groupButtons = document.createElement("div");
    groupButtons.className = "d-flex  justify-content-end";

    if (SessionUserID == UserID) {
        var deleteButton = document.createElement("input");
        deleteButton.type = "button";
        deleteButton.className = "button";
        deleteButton.ariaLabel = "Видалити";
        deleteButton.value = "✖";
        deleteButton.setAttribute("onclick","sendInModalMessageID(this)");
        deleteButton.setAttribute("data-bs-toggle", "modal");
        deleteButton.setAttribute("data-bs-target", "#deleteModal");

        var editButton = document.createElement("input");
        editButton.type = "button";
        editButton.className = "button";
        editButton.ariaLabel = "Редагувати";
        editButton.value = "ED";
        editButton.setAttribute("onclick", "BeginEdit(this)");

        groupButtons.appendChild(deleteButton);
        groupButtons.appendChild(editButton);

        containerButtons.appendChild(groupButtons);
    }
    else if (SessionUserID != UserID && document.getElementById("typeRoom").value=="True") {
        var answerButton = document.createElement("input");
        answerButton.type = "button";
        answerButton.className = "button";
        answerButton.ariaLabel = "Відповісти";
        answerButton.value = "@";

        groupButtons.appendChild(answerButton);
        containerButtons.appendChild(groupButtons);
    }

    var divBlock = document.createElement("div");
    divBlock.className = "flex-shrink-1 bg-light rounded py-2 px-3 ml-3";

    var inputRoomId = document.createElement("input");
    inputRoomId.value = RoomID;
    inputRoomId.type = "hidden";

    var divName = document.createElement("div");
    divName.className = "font-weight-bold mb-1 fw-bold";
    divName.textContent = UserName;

    var divText = document.createElement("div");
    divText.textContent = MessageText;
    divText.id = "text-messege-" + MessageId;
    divText.setAttribute("values", MessageId);;

    var divDate = document.createElement("div");
    divDate.className = "d-flex flex-row justify-content-end p-1";
    divDate.textContent = dateStr;
    divDate.id = "date-message-" + MessageId;
        //MessageDate;

    divBlock.appendChild(inputRoomId);
    divBlock.appendChild(divName);
    divBlock.appendChild(document.createElement("p"));
    divBlock.appendChild(divText);

    container.appendChild(containerButtons);
    container.appendChild(divBlock);
    container.appendChild(divDate);
    document.querySelector('#chat').appendChild(container);
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

function EditMessage(MessageId, MessageText) {
    var editMessage = document.getElementById("text-messege-" + MessageId);
    editMessage.textContent = MessageText;
}

function deleteMessage(MessageId) {
    document.getElementById("message-" + MessageId).remove();
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
