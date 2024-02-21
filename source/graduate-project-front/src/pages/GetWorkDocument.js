import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ModelOutputDoc from '../components/table/ModelOutputDoc';
import GetListInstancesDoc from '../components/GetInstances/GetListInstancesDoc'
import './GetWorkDocument.css'
function GetWorkDocument({resultModel}) {
    const [documents, setDocuments] = useState([]);
    const [documentId, setDocumentId] = useState();

    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`https://localhost:7252/api/Document?resultModel=${resultModel}`);
                setDocuments(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
            
        };

        fetchData();
    }, []); 

    return (
        <div className="centered-content">
            <div>
                <div className="my-4">
                        <div className="rounded-lg overflow-hidden shadow-lg">
                            <ModelOutputDoc documents={documents} onDocumentClick={handleDocumentClick} />
                        </div>
                </div>
                <div className="my-4">
                        <div className="rounded-lg overflow-hidden shadow-lg">
                            <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                        </div>
                </div>
            </div>
        </div>
    );
}

export default GetWorkDocument;
