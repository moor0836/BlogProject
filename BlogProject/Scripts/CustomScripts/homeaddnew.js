$(document).ready(function () {
    LoadCategories();
})

function LoadCategories() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44390/categories",
        success: function (categories) {
            var x = document.getElementById('categories');

            $.each(categories, function (index, category) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(category.Text));
                option.value = category.Id;
                x.appendChild(option);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadcategories failure!");
        }
    });
}

function UpdateHiddenTextBox() {
    document.getElementById('hiddencategoryidtextbox').value = document.getElementById('categories').value();
}