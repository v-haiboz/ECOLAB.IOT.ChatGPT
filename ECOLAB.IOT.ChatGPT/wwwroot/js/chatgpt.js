var ChatGPT = new Object();

ChatGPT.API = {
    SendMessage: function (data) {
        if (data == null || data == undefined || data == "") {
            return;
        };

        $.ajax({
            method: "POST",
            url: "/ChatGPTAPI/Chat",
            beforeSend: function () {
                ChatGPT.API.AppendAI(data);
            },
            data: { content: data, location: "Boston" }
        })
            .done(function (result) {
                if (result != null && result != undefined && result != "" && result.summary != "") {
                    ChatGPT.API.AppendQuestion(result.summary);
                }
            })
    },
    AppendAI: function (content) {
        if (content != null && content != undefined && content != "") {
            $("#container_Main").append("<div class='container darker'><img src = '/img/2.jpg' alt = 'Avatar' class='right' style = 'width:100%;'><p>" + content + "</p><span class='time-left'>" + ChatGPT.API.GetTimeNow() + "</span></div >");
            $('.msg').val("");
        }
    },
    AppendQuestion: function (content) {
        if (content != null && content != undefined && content != "") {
            $("#container_Main").append("<div class='container'><img src = '/img/1.jpg' alt = 'Avatar' class='' style = 'width:100%;'><p>" + content + "</p><span class='time-right'>" + ChatGPT.API.GetTimeNow() + "</span></div >");
        }
    },
    GetTimeNow: function () {
        var myDate = new Date;
        var year = myDate.getFullYear();
        var mon = myDate.getMonth() + 1;
        var date = myDate.getDate();
        var hour = myDate.getHours();
        var min = myDate.getMinutes();
        var second = myDate.getSeconds()
        return year + "-" + ChatGPT.API.GetNow(mon) + "-" + ChatGPT.API.GetNow(date) + " " + ChatGPT.API.GetNow(hour) + ":" + ChatGPT.API.GetNow(min) + ":" + ChatGPT.API.GetNow(second);
    },
    GetNow: function (s) {
        return s < 10 ? '0' + s : s;
    }
}

function submitForm() {
    var data = $('.msg').val();
    ChatGPT.API.SendMessage(data);
}

function init() {
    ChatGPT.API.AppendQuestion("Hi, ECOLAB AI 帮你排忧解难.但我劝你善良,提问的时候好好想想.");
}

$(document).ready(function () {
    init();
});

