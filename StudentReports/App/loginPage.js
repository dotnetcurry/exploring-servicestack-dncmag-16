(function (window) {
    function activateLoginPage() {
        $("#loginForm").submit(function (e) {
            var formData = $(this).serialize();
            var loginUrl = $(this).attr("action");

            $.ajax({
                url: loginUrl,
                type: "POST",
                data: formData
            }).then(function (data) {
                $.ajax({ url: '/assignroles?format=json', type: 'POST', data: { "userName": "ravi", "roles": "Admin" } });
                location.replace(decodeURIComponent(location.href.substr(location.href.indexOf("=") + 1)));
            }, function (e) {
                console.log(e);
                alert(e.statusText);
            });

            e.preventDefault();
        });
    }

    window.activateLoginPage = activateLoginPage;
}(window));