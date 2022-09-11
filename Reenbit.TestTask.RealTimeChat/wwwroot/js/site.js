
var roomID = document.getElementById("chatId").value;
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendButton").disabled = true;
connection.on("ReceiveMessage", function (MessageId, MessagesUserID, UserName, MessageText, MessageDate) {
    $.ajax({
        url: '/Home/GetUserId',
        type: 'POST',
        async: true
        ,
        success: (UserId) => {
            OverWriteAddMessages(MessageId, MessagesUserID, UserName, MessageText, MessageDate, UserId)
        }
    })
});
connection.on("EditMessage", function (MessageId,MessageText) {
    EditMessage(MessageId, MessageText);
});
connection.on("DeleteMessage", function (MessageId) {
    deleteMessage(MessageId);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    connection.invoke('joinRoom', roomID);
}).catch(function (err) {
    return console.error(err.toString());
});

window.addEventListener('onunload', function () {
    connection.invoke('leaveRoom', roomID);
})



document.getElementById("sendButton").addEventListener("click", function (event) {
        var message = document.getElementById("messageInput").value;
        document.getElementById('messageInput').value = "";
        var idRoom = document.getElementById("chatId").value;
        $.ajax({
            url: '/Home/SendMessage',
            type: 'POST',
            data: {
                TextMessage: message,
                RoomId: idRoom
            },
            async: true
        });
        event.preventDefault();
});
