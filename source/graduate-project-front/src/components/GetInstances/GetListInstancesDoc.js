import { useState, useEffect } from "react";
import axios from "axios";
import TableInstancesDoc from "./TableInstancesDoc";

function GetListInstancesDoc({ documentId }) {
    const [instancesDoc, setInstancesDoc] = useState(null); // Изначально устанавливаем значение как null

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/Document/${documentId}`);
                setInstancesDoc(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [documentId]);

    // Если instancesDoc не равно null, возвращаем компонент TableInstancesDoc,
    // иначе возвращаем надпись "Данный документ не имеет своего маршрута инстанций"
    return (
        <>
           {(instancesDoc !== null && instancesDoc.length !== 0) ? (
                <TableInstancesDoc instancesDoc={instancesDoc} />
            ) : (
                <p>Документ с ключем {documentId} не имеет своего маршрута инстанций</p>
            )}

        </>
    );
}

export default GetListInstancesDoc
