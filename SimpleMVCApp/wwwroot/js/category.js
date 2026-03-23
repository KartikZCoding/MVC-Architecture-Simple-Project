$(document).ready(function () {
    loadCategories();
    $("#loadCategory").click(loadCategories);
    $("#createNewBtn").click(showCreateForm);
    $("#categoryForm").submit(saveCategory);
});

function loadCategories() {
    $.ajax({
        url: "/Category/GetAll",
        method: "GET",
        success: function (res) {
            if (res.success) {
                renderTable(res.data);
            } else {
                alert(res.message || "Failed to load categories");
            }
        },
        error: function () {
            alert("Failed to load items");
        }
    });
}

function renderTable(categories) {
    const tbody = $("#categoryTableBody");
    tbody.empty();

    if (!categories || categories.length === 0) {
        tbody.append(`
            <tr>
                <td colspan="4" style="text-align:center;">No categories found!!</td>
            </tr>
        `);
        return;
    }

    categories.forEach(category => {
        tbody.append(`
            <tr>
                <td>${category.id}</td>
                <td>${category.name}</td>
                <td>${category.description}</td>
                <td>
                    <button onclick="editItem(${category.id})">Edit</button>
                    <button onclick="deleteItem(${category.id})">Delete</button>
                </td>
            </tr>
        `);
    });
}

function deleteItem(id) {
    if (!confirm("Are you sure you want to delete?")) return;

    $.ajax({
        url: "/Category/Delete",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(id),
        success: function (res) {
            if (res.success) loadCategories();
            else alert(res.message || "Delete failed");
        },
        error: function () {
            alert("Delete failed");
        }
    });
}

function editItem(id) {
    $.ajax({
        url: "/Category/GetById?id=" + id,
        method: "GET",
        success: function (res) {
            if (res.success) {
                $("#formSection").show();
                $("#formTitle").text("Update Item");

                $("#categoryId").val(res.data.id);
                $("#name").val(res.data.name);
                $("#description").val(res.data.description);
            } else {
                alert(res.message || "Failed to load item");
            }
        },
        error: function () {
            alert("Failed to load item");
        }
    });
}

function showCreateForm() {
    $("#formSection").show();
    $("#formTitle").text("Create Category");

    $("#categoryForm")[0].reset();
    $("#categoryId").val("");
}

function saveCategory(e) {
    e.preventDefault();

    const id = $("#categoryId").val();

    const payload = {
        id: id ? parseInt(id) : null,
        name: $("#name").val(),
        description: $("#description").val()
    };

    $.ajax({
        url: "/Category/Save",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(payload),
        success: function (res) {
            if (res.success) {
                $("#categoryForm")[0].reset();
                $("#formSection").hide();
                loadCategories();
            } else {
                alert(res.message || "Save failed");
            }
        },
        error: function () {
            alert("Save failed");
        }
    });
}