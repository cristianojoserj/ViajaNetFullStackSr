
function logAccess() {
    $.ajax({
        url: 'https://api.ipify.org?format=jsonp&callback=?',
        type: 'GET',
        dataType: 'json',
        async: false,
        success: function (data) {

            var obj = new Object();
            obj.Ip = data.ip;
            obj.PageName = window.location.pathname.substring(1).replace('/', '');
            obj.BrowserName = getBrowserName();
            obj.Parameters = getUrlParameters().toString();

            var jsonResult = JSON.stringify(obj);

            $.ajax({
                url: "http://localhost:59601/api/Values/save",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: jsonResult,
                dataType: "json",
                success: function (result) {
                    switch (result) {
                        case true:
                            processResponse(result);
                            break;
                        default:
                            resultDiv.html(result);
                    }
                }
            });
        },
        error: function () {
            return "";
        }
    });
}

function getBrowserName() {

    if (navigator.userAgent.indexOf("Edge") > -1 && navigator.appVersion.indexOf('Edge') > -1) {
        return 'Edge';
    }
    else if (navigator.userAgent.indexOf("Opera") != -1 || navigator.userAgent.indexOf('OPR') != -1) {
        return 'Opera';
    }
    else if (navigator.userAgent.indexOf("Chrome") != -1) {
        return 'Chrome';
    }
    else if (navigator.userAgent.indexOf("Safari") != -1) {
        return 'Safari';
    }
    else if (navigator.userAgent.indexOf("Firefox") != -1) {
        return 'Firefox';
    }
    else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
    {
        return 'IE';
    }
    else {
        return 'unknown';
    }
}

function getUrlParameters() {
    var result = '';
    var res = window.location.href.split('?');
    if (res[1] !== undefined)
        result = res[1].split('&');
    return result;
}