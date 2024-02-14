import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './IncomingDocWork.css';
import ModelOutputDoc from './table/ModelOutputDoc';

function IncomingDocWork() {
    const [documents, setDocuments] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get('https://localhost:7252/api/Document?')
                setDocuments(response.data)
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, []); 

    return (
        <div className="centered-content">
            <div className="table-container"> 
               <ModelOutputDoc documents={documents}></ModelOutputDoc>
            </div>
        </div>

    );
}

export default IncomingDocWork;
