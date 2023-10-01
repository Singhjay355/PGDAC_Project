import React, { useState , useEffect} from 'react'
import { useParams } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import ProductCard from '../../components/ProductCard';

const ProductPage = () => {

    const [product,setProduct] = useState([]); 
    const { id } = useParams();
    let navigate = useNavigate();

    const handleClick = (prodID) => {
      
      
    };

    useEffect(() => {
        fetch('http://localhost:5062/api/Product/ByCategory/' + id)
          .then(response => response.json())
          .then(data => {
            setProduct(data);
            console.log(data);
          })
          .catch(error => console.error('Error fetching data:', error));
      }, [id]);

  return (
    <div style={{ margin: '20px', display: 'flex', padding: '2%' }}>
        {product?.map((i) => (
          <div key={i.prodID} onClick={() => handleClick(i.prodID)}  style={{ padding: '10px' }}>
            <ProductCard id={i.prodID} prodName={i.prodName} imgPath={i.imgPath} prodShortDesc={i.prodShortDesc} offerPrice={i.offerPrice} mrpPrice={i.mrpPrice} prodLongDesc={i.prodLongDesc} />
          </div>
           ))}
    </div>
  )
}

export default ProductPage