import { useState, useEffect } from "react";
import axios from "axios";
import TableInstanceDoc from "./TableInstanceDoc.";
import "./GetListInstancesDoc.css"

function GetListInstancesDoc({ documentId }) {
    const [instancesDoc, setInstancesDoc] = useState(null); 

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:5254/api/Document/${documentId}`);
                setInstancesDoc(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [documentId]);

    
    return (
        <>
           {(instancesDoc !== null && instancesDoc.length !== 0) ? (
                <TableInstanceDoc instancesDoc={instancesDoc} />
            ) : (
                <p className="text-error ms-5">Документ с ключем {documentId} не имеет своего маршрута инстанций!</p>
            )}

        </>
    );
}

export default GetListInstancesDoc