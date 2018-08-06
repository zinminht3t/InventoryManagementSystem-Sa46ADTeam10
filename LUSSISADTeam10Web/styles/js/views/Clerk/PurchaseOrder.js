

function addRow() {

            @{
        Model.podms.Add(new LUSSISADTeam10Web.Models.Clerk.PurchaseOrderDetailViewModel());


    }



    var index = $("#tbpodms").children("tr").length;

    var option = $("#optionvlaues").text();

    var indexCell = "<td style='display:none'><input name='podms.Index' type='hidden' value='" + index + "' /></td>";
    var titleCell = "<td><select class='form-control' onChange='getSupplierList(this.selectedIndex, podms_" + index + "__Titlea)' id='podms_" + index + "__Title' name='podms[" + index + "].Itemid'>" + option  + "</select></td>";
    var publishedCell = "<td class='qtyinput'><input  class='form-control' required='required' id='podms_" + index + "__Title' name='podms[" + index + "].Qty' min='1'  type='number' value='100' /></td>";
    var suppliercell = "<td class='supinput'><select  class='form-control' required='required' id='podms_" + index + "__Titlea' name='podms[" + index + "].SupplierID'></select></td>";
    var removeCell = "<td class='btnremove'><input id='btnAddReqD' type='button' class='btn btn-outline-danger btn-sm' value='Remove' onclick='removeRow(" + index + ");' /></td>";
    var newRow = "<tr id='trReqD" + index + "'>" + indexCell + titleCell + publishedCell + suppliercell + removeCell + "</tr>";
            $("#tbpodms").append(newRow);

}

        function getSupplierList(id, pageid) {
                        $.ajax({
                        url: '@Url.Action("GetSupplierLists", "Clerk")',
                        data: { ID: id },
                        type: 'GET',
                        success: function (data) {
                            $(pageid).html(data);
                        }
                    });
        }

        function removeRow(id) {
            var controlToBeRemoved = "#trReqD" + id;
            $(controlToBeRemoved).remove();
        }


