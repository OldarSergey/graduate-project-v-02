import axios from "axios";
import React, { useState, useEffect } from 'react';
import ModelOutputDoc from "../../components/table/ModelOutputDoc";
import GetListInstancesDoc from "../../components/GetInstances/GetListInstancesDoc";

function DocumentArchive({keyNote, year}){

    const[docArchive, setDocArchive] = useState([]);
    const [archiveId, setArchiveId] = useState();
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(25);

    const handleDocumentClick = (id) => {
        setArchiveId(id);
    };


    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/Document/archive/${keyNote}/${keyNote}/${pageNumber}/${pageSize}?userId=23546`);
                setDocArchive(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [keyNote, year, pageNumber, pageSize]);


    return(
        <div className="centered-content ml-4 overflow-hidden">
        <div className="overflow-hidden mt-5">
            <div className="my-4 " style={{ width: "100%", overflowY: 'auto', maxHeight: '50vh' }}>
                <div className='max-h-96' >
                    <ModelOutputDoc documents={docArchive} onDocumentClick={handleDocumentClick}/>
                </div>
            </div>
            
            
            <div className="my-4" style={{ width: "100%", overflowY: 'auto', height: '40vh' }}>
                <div>
                    <GetListInstancesDoc documentId={archiveId}></GetListInstancesDoc>
                </div>
            </div>
        </div>  
    </div>
    )
}
export default DocumentArchive;



