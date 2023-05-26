$(function () {
    debugger;
    getList();
});
function getList() {
    debugger;
    $.ajax
        (
            {
                type: "GET",
                url: "/Company/GetCompany",
                success: function (data) {
                    debugger;

                    $('#datatable').DataTable().clear().destroy();

                    $('#datatable').dataTable
                        (
                            {
                                processing: true,
                                "aaData": data,
                                "order": [[0, 'asc']],
                                "columns": [

                                    { "data": "companyId" },
                                    { "data": "companyName" },
                                    { "data": "address" },
                                    { "data": "cityId" },
                                    { "data": "stateId" },
                                    { "data": "pin" },
                                    { "data": "contactNo" },
                                    { "data": "email" },

                                    {
                                        "mRender": function (data, type, row) {
                                            return ' <a id="btnedit" href="#" onclick="edit(' + row.companyId + ')" title="Edit"  data-id=' + row.companyId + '>Edit</a>';
                                        }
                                    },
                                    {
                                        "mRender": function (data, type, row) {
                                            return ' <a id="btndelete" href="#" onclick="deleteCompany(' + row.companyId + ')" title="Delete"  data-id=' + row.companyId + '>Delete</a>';
                                        }
                                    },

                                ]
                            }
                        )

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            }
        );
}

//function edit(id) {
//    debugger
//    alert(id)
//    if (confirm("Are you sure you want to edit this product record??")) {
//        $.get("/Company/EditManageCompany/" + id,
//            function (res) {
//                if (res == "Deleted Sucessfully") {
//                    debugger
//                    alert("Record Deleted")
//                    getList();
//                }
//                else {
//                    alert("Deletion Unsuccessful")
//                    getList();
//                }
//            });
//    }

//};


function deleteCompany(id){
    debugger
    alert(id)
    if (confirm(id + "Are you sure you want to edit this product record??")) {
        $.get("/Company/DeleteManageCompany/" + id,
            function (res) {
                if (res == true) {
                    debugger
                    alert("Record Deleted")
                    getList();
                }
                else {
                    alert("Deletion Unsuccessful")
                    getList();
                }
            });
    }
};

