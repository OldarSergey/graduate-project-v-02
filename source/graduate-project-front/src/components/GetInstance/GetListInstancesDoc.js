import { useState, useEffect } from "react";
import axios from "axios";
import TableInstanceDoc from "./TableInstanceDoc.";

function GetListInstancesDoc({ documentId }) {
    const [instancesDoc, setInstancesDoc] = useState(null); 

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:9982/api/Document/${documentId}`);
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
                <p>Документ с ключем {documentId} не имеет своего маршрута инстанций</p>
            )}

        </>
    );
}

export default GetListInstancesDoc