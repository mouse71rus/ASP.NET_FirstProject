$(document).ready(function () {

    $(".deleteRow").click(function () {
        if (confirm("Вы действительно хотите удалить контакт?")) {
            var thisID = $(this).attr("data-id");
            var parrent = $(this).parent().parent();
            $.post("/home/delete", { id: thisID }, function (data) {
                if (data == "Ok") {
                    $(parrent).remove();
                }
                else {
                    alert(data);
                }
            });
        }

        return false;

    })

});