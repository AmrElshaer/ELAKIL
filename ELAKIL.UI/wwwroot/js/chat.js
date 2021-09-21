"use strict";
ScrollMsgHistoryToEnd();
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentUser = $("#currentUser").val();
    if (user == currentUser) {
        $("#msg_history").append(addInCommingMessage(message));
        ScrollMsgHistoryToEnd();
    }
    
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    const user = document.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;
    $("#msg_history").append(addOutGogingMessage(message));
    document.getElementById("messageInput").value = "";
    ScrollMsgHistoryToEnd();
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
function ScrollMsgHistoryToEnd() {
    $(".msg_history").stop().animate({ scrollTop: $(".msg_history")[0].scrollHeight }, 1000);
}
function addInCommingMessage(message) {
    const result = `<div class="incoming_msg">
            <div class="incoming_msg_img"> <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil"> </div>
            <div class="received_msg">
                <div class="received_withd_msg">
                    <p>
                       ${message}
                    </p>
                </div>
            </div>
        </div>`;
    return result;
}

function addOutGogingMessage(message) {
    const result = ` <div class="outgoing_msg">
                        <div class="sent_msg">
                            <p>
                               ${message}
                            </p>
                        </div>
                    </div>`;
    return result;
}