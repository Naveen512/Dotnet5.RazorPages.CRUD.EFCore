// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function deleteGadget(id) {
  url = "/all-gadgets?id=" + id + "&handler=delete";
  var deleteFormEl = document.getElementById("confirmDelete");
  deleteFormEl.setAttribute("action", url);
  $("#deleteGadgetModal").modal("show");
}

function closeModal() {
  $("#deleteGadgetModal").modal("hide");
}
