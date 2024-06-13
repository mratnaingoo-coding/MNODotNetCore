// for animation words
var typed = new Typed(".typing", {
    strings: ["Add your product!", "Search what you want!", "Designed by Rikzil"],
    typeSpeed: 100,
    BackSpeed: 60,
    loop: true
})

// For product


const tblProduct = "products";
const tblCart = "carts";
let productId = null;

getProductTable();
getCartTable();
function readProduct() {
    let lst = getProducts();
}

function createProduct(name, price, category) {

    let lst = getProducts();

    const requestModel = {
        id: uuidv4(),
        name: name,
        price: price,
        category: category
    };
    lst.push(requestModel);
    const jsonProduct = JSON.stringify(lst);
    setTimeout(() => {
        successMessage("Saving success.");
    }, 2000)

    localStorage.setItem(tblProduct, jsonProduct);
    clearControls();
}

function editProduct(id) {

    let lst = getProducts();

    const items = lst.filter(x => x.id === id);
    console.log(items)

    console.log(items.length)

    if (items.length == 0) {
        console.log("no data was found.")
        errorMessage("No data was found.")
        return;
    }
    // return items[0];
    let item = items[0];
    productId = item.id;
    $('#txtName').val(item.name);
    $('#txtPrice').val(item.price);
    $('#txtCategory').val(item.category);
    $('#txtName').focus();
}

function updateProduct(id, name, price, category) {

    let lst = getProducts();

    const items = lst.filter(x => x.id === id);
    // console.log(items)

    console.log(items.length)

    if (items.length == 0) {
        console.log("no data was found.")
        errorMessage("No data was found.")
        return;
    }
    const item = items[0];
    item.name = name;
    item.price = price;
    item.category = category;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonProduct = JSON.stringify(lst)
    localStorage.setItem(tblProduct, jsonProduct)
    setTimeout(() => {
        successMessage("Updating successful.");
    }, 2000)

}


function deleteProduct(id) {
    Swal.fire({
        title: "Are you sure?",
        text: "They'll permanently delete it!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {


            let lst = getProducts();

            const items = lst.filter(x => x.id === id);
            if (items.length == 0) {
                console.log("no data was found.")
                return;
            }
            lst = lst.filter(x => x.id !== id);

            const jsonProduct = JSON.stringify(lst)
            localStorage.setItem(tblProduct, jsonProduct)
            setTimeout(() => {
                successMessage("Deleting success.");
            }, 2000)

            getProductTable();
        }
    });
}

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
        .replace(/[xy]/g, function (c) {
            const r = Math.random() * 16 | 0,
                v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
}

function getProducts() {
    const products = localStorage.getItem(tblProduct);
    // console.log(blogs)

    let lst = [];
    if (products !== null) {
        lst = JSON.parse(products);
    }
    return lst;
}

$('#btnSave').click(function () {
    const name = $('#txtName').val();
    const price = $('#txtPrice').val();
    const category = $('#txtCategory').val();
    if (productId === null) {
        createProduct(name, price, category);
    } else {
        updateProduct(productId, name, price, category);
        productId = null;
    }
    getProductTable();
})

$('#btnCancel').click(function () {
    clearControls();
})

function successMessage(message) {
    Swal.fire({
        title: message,
        showClass: {
            popup: `
            animate__animated
            animate__fadeInUp
            animate__faster
          `
        },
        hideClass: {
            popup: `
            animate__animated
            animate__fadeOutDown
            animate__faster
          `
        }
    });
}
function errorMessage(message) {
    Swal.fire({
        icon: "error",
        title: "Oops...",
        text: message
    });
}

function clearControls() {
    $('#txtName').val('');
    $('#txtPrice').val('');
    $('#txtCategory').val('');
    $('#txtName').focus();
}


function getProductTable() {
    const lst = getProducts();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow =
            `   <tr>
            <td>
            <button type="button" class="btn btn-warning" onclick="editProduct('${item.id}')">Edit</button>
            <button type="button" class="btn btn-danger" onclick="deleteProduct('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.name}</td>
            <td>${item.price}</td>
            <td>${item.category}</td>
            <td>
                <button type="button" class="btn btn-primary" onclick="addCartProduct('${item.id}')">
                <i class="fa-solid fa-plus"></i>
                </button>
            </td>
        </tr>
    `;
        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
}

function getCarts() {
    let carts = localStorage.getItem(tblCart);
    // console.log(carts)

    let lst = [];
    if (carts !== null) {
        lst = JSON.parse(carts);
    }
    return lst;
}

function getCartTable() {
    const lst = getCarts();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow =
            `   <tr>
            
            <td>${++count}</td>
            <td>${item.cartName}</td>
            <td>${item.cartPrice}</td>
            <td>
                <button type="button" class="btn btn-primary" onclick="addCount('${item.cartId}')">
                <i class="fa-solid fa-plus"></i>
                </button>
                <span class="unit-count"> ${item.cartUnit} </span>
                <button type="button" class="btn btn-primary" onclick="subCount('${item.cartId}')">
                <i class="fa-solid fa-minus"></i>
                </button>
            </td>
            <td>${item.cartCategory}</td>
            <td>${item.cartUnit * item.cartPrice}</td>
            <td>
                <button class="btn btn-danger" onclick="deleteCart('${item.cartId
                }')"><i class="fa-solid fa-trash"></i></button>
                </td>
        </tr>
    `;
        htmlRows += htmlRow;
    });
    $('#cbody').html(htmlRows);
}

function addCartProduct(id) {
    let cartItem = getCarts();
    let item = getProducts();

    let productLst = item.filter((x) => x.id === id);
    let product = productLst[0];

    let index = cartItem.findIndex((x) => x.cartId === id);
    if (index === -1) {
        const requestCart = {
            cartId: uuidv4(),
            cartProductId: product.id,
            cartName: product.name,
            cartPrice: product.price,
            cartUnit: 1,
            cartCategory: product.category
        };
        cartItem.push(requestCart);
    } else {
        cartItem[index].cartUnit += 1;
    }

    const cartStr = JSON.stringify(cartItem);
    localStorage.setItem(tblCart, cartStr);

    getCartTable();
}
$('document').ready(function () {
    new DataTable('#productList');
    new DataTable('#cartList');
})

function addCount(id){
    let cartLst = getCarts();
    let index = cartLst.findIndex((x) => x.cartId === id);
    if (index !== null) {
      cartLst[index].cartUnit += 1;
      const cartStr = JSON.stringify(cartLst);
      localStorage.setItem(tblCart, cartStr);
      getCartTable();
    }
}
function subCount(id){
    let cartLst = getCarts();
    let index = cartLst.findIndex((x) => x.cartId === id);
    if (index !== null && cartLst[index].cartUnit > 1) {
      cartLst[index].cartUnit -= 1;
      const cartStr = JSON.stringify(cartLst);
      localStorage.setItem(tblCart, cartStr);
      getCartTable();
    }
}
function deleteCart(id){
    Swal.fire({
        title: "Are you sure?",
        text: "They'll permanently delete it!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {


            let lst = getCarts();

            const items = lst.filter(x => x.cartId === id);
            if (items.length == 0) {
                console.log("no data was found.")
                return;
            }
            lst = lst.filter(x => x.cartId !== id);

            const jsonCart = JSON.stringify(lst)
            localStorage.setItem(tblCart, jsonCart)
            setTimeout(() => {
                successMessage("Deleting success.");
            }, 2000)

            getCartTable();
        }
    });
}