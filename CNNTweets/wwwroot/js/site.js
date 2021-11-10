$(function () {
    //Edit event handler.
    $("#edit-btn").click(function () {
        $('#display-name').hide();
        $('#published-date').hide();
        $('#display-name-input').show();
        $('#published-date-input').show();

        $('.table tr').each(function (row) {
            $("td", row).each(function () {
                $(this).find("input").show();
                $(this).find("textarea").show();
                $(this).find("p").hide();
                $(this).find("a").hide();
            });
        });

        $("#cancel-btn").show();
        $(this).hide();
    });

    //Cancel event handler.
    $("#cancel-btn").click(function () {

        $('.table tr').each(function (row) {
            $("td", row).each(function () {
                var p = $(this).find("p");
                var a = $(this).find("a");
                var input = $(this).find("input");
                input.val(p.html());
                p.show();
                a.show();
                
                input.hide();
                $(this).find(".link-input").val(a.attr('href'));
            });
        });

        $("#edit-btn").show();
        $(this).hide();
    });
});
