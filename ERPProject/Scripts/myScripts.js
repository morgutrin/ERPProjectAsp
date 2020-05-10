var contractors = []

function LoadContractors(element) {
    if (contractors.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Warehouse/GetContractors",
            success: function (data) {
                contractors = data;
            }
        })
    } else {

    }
}