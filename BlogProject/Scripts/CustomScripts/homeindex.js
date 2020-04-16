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

function UpdatePosts() {
    if (document.getElementById('categories').value == "-1") {
        window.location.href = "https://localhost:44390";
    }
    else {
        $('#blogPostSection').empty();
        $.ajax({
            type: "GET",
            url: "https://localhost:44390/getpostsbycategoryid?id=" + document.getElementById('categories').value,
            success: function (blogPosts) {
                var spot = document.getElementById('blogPostSection');
                $.each(blogPosts, function (index, x) {
                    var result =
                        '<div class="row blogRow">' +
                        '<div class="col-sm-12">' +
                        '<div class="row">' +
                        '<div class="col-sm-8 title">' +
                        '<h4><a href="https://localhost:44390/Home/Details?id=@x.BlogId">' + x.Title + '</a> </h4><br />' +
                        '</div>' +
                        '<div class="col-sm-4 author">' +
                        '<p>Author: ' + x.Author + '</p><br />' +
                        '</div>' +
                        '</div>' +
                        '<div class="row">' +
                        '<div class="col-sm-12">' +
                        '<p>' + x.PreviewText + '</p>' +
                        '</div>' +
                        '<div class="col-sm-6">' +
                        '<p>Category: ' + x.Category.Text + '</p>' +
                        '</div>' +
                        '<div class="col-sm-6 publishDate">' +
                        '<p><i>Published: ' + x.DateCreated.substring(0, 10) + '</i></p>' +
                        '</div>' +
                        '</div>' +
                        '<div class="row">' +
                        '<div class="col-sm-12">' +
                        '<p>' +
                        'Tags: ';
                    $.each(x.Tags, function (index, tag) {
                        result += '<span> ' + tag + ' </span>';
                    })
                    result += '</p ></div ></div ></div ></div >';
                    spot.innerHTML += (result);
                });
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("updatePosts failure!");
            }
        });
    }
}

function Reset() {
    window.location.href = "https://localhost:44390";
}

function SearchPosts() {
    var searchText = document.getElementById('searchtagtext').value;
    searchText = searchText.replace(/#/g, "");
    $('#blogPostSection').empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44390/searchpostsbytag?tags=" + searchText,
        success: function (blogPosts) {
            var spot = document.getElementById('blogPostSection');
            $.each(blogPosts, function (index, x) {
                var result =
                    '<div class="row blogRow">' +
                    '<div class="col-sm-12">' +
                    '<div class="row">' +
                    '<div class="col-sm-8 title">' +
                    '<h4><a href="https://localhost:44390/Home/Details?id=@x.BlogId">' + x.Title + '</a> </h4><br />' +
                    '</div>' +
                    '<div class="col-sm-4 author">' +
                    '<p>Author: ' + x.Author + '</p><br />' +
                    '</div>' +
                    '</div>' +
                    '<div class="row">' +
                    '<div class="col-sm-12">' +
                    '<p>' + x.PreviewText + '</p>' +
                    '</div>' +
                    '<div class="col-sm-6">' +
                    '<p>Category: ' + x.Category.Text + '</p>' +
                    '</div>' +
                    '<div class="col-sm-6 publishDate">' +
                    '<p><i>Published: ' + x.DateCreated.substring(0, 10) + '</i></p>' +
                    '</div>' +
                    '</div>' +
                    '<div class="row">' +
                    '<div class="col-sm-12">' +
                    '<p>' +
                    'Tags: ';
                $.each(x.Tags, function (index, tag) {
                    result += '<span> ' + tag + ' </span>';
                })
                result += '</p ></div ></div ></div ></div >';
                spot.innerHTML += (result);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("updatePosts failure!");
        }
    });
}