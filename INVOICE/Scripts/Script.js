

function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}


 var products=[];
var TotalCount=0;


function AddToCart(id)
    {
TotalCount=TotalCount+1;
product={Id:id, Count:1};
   if (products.find(x=>x.Id===id))
{
products.find(x=>x.Id===id).Count=products.find(x=>x.Id===id).Count+1;
}
else{
    products.push(product);
}
    $("#cartCount").html(TotalCount)
    
    
    }
function GoToCart(){
  $.ajax({  
        type: "POST", 
        url:"/api/Cart/setCartItem",  
        data: JSON.stringify(products),  
        contentType: "application/json",  
        success: function (result) {  
          window.location.href="/AddToCart/Myorder";
        },  
        error: function (errormessage) {  
              
        }  
    });
}