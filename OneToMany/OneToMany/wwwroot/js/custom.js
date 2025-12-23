let loadMore = document.querySelector(".load-more");

loadMore.addEventListener("click", function () {
    let htmlProductCount = document.querySelectorAll(".product").length;

    let dbProductCount = document.querySelector(".product-count").value;

    console.log(dbProductCount);

    fetch(`Home/LoadMore?skip=${htmlProductCount}`)
        .then(response => response.text())
        .then(response => {
            let parent = document.querySelector(".load-products");

            parent.innerHTML += response;

            let htmlProductCount = document.querySelectorAll(".product").length;

            if (htmlProductCount >= dbProductCount) {
                this.style.display = "none";
            }
        })
});