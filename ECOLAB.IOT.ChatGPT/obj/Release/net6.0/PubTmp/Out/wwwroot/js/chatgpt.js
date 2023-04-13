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
                ChatGPT.API.AppendQuestion(data);
                $('.loading').addClass('show').removeClass('hidden');
            },
            data: { content: data, location: "Boston" }
        })
            .done(function (result) {
                if (result != null && result != undefined && result != "" && result.summary != "") {
                    ChatGPT.API.AppendAI(result.summary);
                }
                $('.loading').addClass('hidden').removeClass('show');
            })
    },
    AppendQuestion: function (content) {
        if (content != null && content != undefined && content != "") {
            $("#container_Main").append(`<div class='container darker'><img src = '/img/` + questionerImgIndex +`.jpg' alt = 'Avatar' class='right' style = 'width:100%;'><p>` + content + `</p><span class='time-left'>` + ChatGPT.API.GetTimeNow() + `</span></div >`);
            $('.msg').val("");
        }
    },
    AppendAI: function (content) {
        if (content != null && content != undefined && content != "") {
            $("#container_Main").append("<div class='container'><img src = '/img/ai.png' alt = 'Avatar' class='' style = 'width:100%;'><p>" + content + "</p><span class='time-right'>" + ChatGPT.API.GetTimeNow() + "</span></div >");
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
       /* return year + "-" + ChatGPT.API.GetNow(mon) + "-" + ChatGPT.API.GetNow(date) + " " + ChatGPT.API.GetNow(hour) + ":" + ChatGPT.API.GetNow(min) + ":" + ChatGPT.API.GetNow(second);*/
        return ChatGPT.API.GetNow(hour) + ":" + ChatGPT.API.GetNow(min) + ":" + ChatGPT.API.GetNow(second);
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
    ChatGPT.API.AppendAI(`Hi, 我是ECOLAB AI,可以查询数据，并进行诊断。支持的字段如下：WashTemperature,RinseTemperature,RackAmount,Ratio_BadWashTemperature,Ratio_BadRinseTemperature,Ratio_LackofRinseaid,Ratio_LackofDetergent,Ratio_NeedWaterChange,Ratio_Interrupted,LastHeartBeat

        你可以这样问我：设备DMC-DMC200114029 最近5天情况如何 ?

        也可以这样问我 : 设备DMC-DMC200114029 最近5天洗涤温度小于60度的情况发生了几次 ?.`);
}

$(document).ready(function () {
    init();
});

