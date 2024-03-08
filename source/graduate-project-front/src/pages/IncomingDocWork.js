import React, { useState, useEffect } from 'react';
import axios from 'axios';
import ModelOutputDoc from '../components/table/ModelOutputDoc';
import GetListInstancesDoc from '../components/GetInstances/GetListInstancesDoc';
import "./IncomingDocWork.css"
import { NavLink } from 'react-router-dom';

function IncomingDocWork(){ 
    const [documents, setDocuments] = useState([]);
    const [documentId, setDocumentId] = useState();
    const [nameProcedure, setNameProcedure] = useState("Doc_Documents")


    
    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:9902/api/Document?resultModel=${1}`);
                setDocuments(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }           
        };
        fetchData();
    }, []); 

    return (
        <div className="centered-content  ml-4" style={{width:"70%"}} >
            <div className='mt-5'>
            <NavLink to="../IncomingDocWork" className="nav-button blue-button" activeClassName="active-button">В работе</NavLink>
            <NavLink to="../IncomingDocSpent" className="nav-button blue-button" activeClassName="active-button">Отработанные</NavLink>

            </div>
           <div >
                <div className="my-4 mt-5" style={{ width: "70%", overflowY: 'auto', height: '50vh' }}>
                        <div className="rounded-lg shadow-lg">
                            <ModelOutputDoc documents={documents} onDocumentClick={handleDocumentClick}/>
                        </div>
                </div>
                <div className="my-4 mt-2" style={{ width: "100%", overflowY: 'auto', height: '40vh' }}>
                        <div className="rounded-lg">
                            <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                        </div>
                </div>
            </div>
        </div>
    );
}
export default IncomingDocWork;