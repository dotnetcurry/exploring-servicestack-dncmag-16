(function (window) {
    function activateMarksRequestPage(studentId) {
        $("#btnAddMarks").click(function () {
            $("#divNewMarks").show();
        });

        $("#btnAddNewMarks").click(function () {
            var newMarks = $("#formNewMarks").serialize();

            $.post("/marks?format=json", newMarks)
                .then(function (result) {
                    window.location.reload();
                });
        });

        $("#btnUpdateMarks").click(function (e) {
            e.preventDefault();

            var updatedMarks = {
                id: $("#hnMarksId").val(),
                subject: $("#txtSubjectUpdate").val(),
                maxMarks: $("#txtMaxMarksUpdate").val(),
                marksAwarded: $("#txtMarksAwardedUpdate").val(),
                studentId: studentId
            };

            $.ajax({
                url: "/marks/" + updatedMarks.id + "?format=json",
                type: "PUT",
                data: updatedMarks
            }).then(function () {
                window.location.reload();
            });
        });

        $("#tblStudentMarks button").on("click", function (event) {
            var marksId = $(event.currentTarget).data("marksId");
            $.get("/marks/" + marksId + "?format=json", function (data) {
                $("#divUpdateMarks").show();
                $("#hnMarksId").val(data.marks[0].id);
                $("#txtSubjectUpdate").val(data.marks[0].subject);
                $("#txtMaxMarksUpdate").val(data.marks[0].maxMarks);
                $("#txtMarksAwardedUpdate").val(data.marks[0].marksAwarded);
            });
        });
    }

    window.activateMarksRequestPage = activateMarksRequestPage;
}(window));