let items = new Array();
const container = document.querySelector('.item_container');

function createOrder()
{
    fetch("/Main/Create", {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify(items)
    }).
    then(res => {
        items = [];
        container.innerHTML = "";
    });
    
}

function createTable(data) {
    html = `<div class="item">
                <div class="item_row">
                    <span class="tool">${data.itemName}</span>
                    <span class="amount">${data.amount}</span>
                </div>
                <div class="item_row">
                    <span class="comment">${data.comment}</span>
                </div>
            </div>`
    container.insertAdjacentHTML("beforeend", html);
}

const form = document.querySelector('[class="form_for_item"]');
form.addEventListener("submit", (event)=> {
    event.preventDefault();
    const itemName = form.querySelector('[name="Name"]'), 
        amount = form.querySelector('[name="Amount"]'), 
        comment = form.querySelector('[name="Comment"]');
    const data = {
        itemName: itemName.value,
        amount: amount.value,
        comment: comment.value,};
    items.push(data);
    createTable(data);
})


const formCreateOrder = document.querySelector('[class="createOrder"]');
formCreateOrder.addEventListener("submit", (event)=> {
    event.preventDefault();
   createOrder();
})
