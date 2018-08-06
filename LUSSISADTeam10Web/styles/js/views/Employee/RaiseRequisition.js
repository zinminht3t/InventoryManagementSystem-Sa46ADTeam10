  function addRow() {

            @{
                Model.Requisitiondetails.Add(new LUSSISADTeam10Web.Models.Employee.RequisitionDetailsViewModel());
            }

            var index = $("#tbRequisitiondetails").children("tr").length;

            var option = $("#optionvlaues").text();

            var indexCell = "<td style='display:none'><input name='Requisitiondetails.Index' type='hidden' value='" + index + "' /></td>";
            var titleCell = "<td><select class='form-control' id='Requisitiondetails_" + index + "__Title' name='Requisitiondetails[" + index + "].Itemid'>" + option  + "</select></td>";
            var publishedCell = "<td><input  class='form-control' required='required' id='Requisitiondetails_" + index + "__Title' name='Requisitiondetails[" + index + "].Qty' type='number' min='1' autofocus value='100' /></td>";
            var removeCell = "<td><input id='btnAddReqD' type='button' class='btn btn-outline-danger' value='Remove' onclick='removeRow(" + index + ");' /></td>";
            var newRow = "<tr id='trReqD" + index + "'>" +  indexCell + titleCell + publishedCell + removeCell + "</tr>";
            $("#tbRequisitiondetails").append(newRow);
        }
        function removeRow(id) {
            var controlToBeRemoved = "#trReqD" + id;
            $(controlToBeRemoved).remove();
        }