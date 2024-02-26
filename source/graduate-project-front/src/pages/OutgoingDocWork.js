import axios from "axios";
import React, { useState, useEffect } from 'react';
import ModelOutputDoc from "../components/table/ModelOutputDoc";
import GetListInstancesDoc from "../components/GetInstances/GetListInstancesDoc";
import './OutgoingDocWork.css'


function OutgoingDocWork() {
    const [documents, setDocuments] = useState([]);
    const [documentId, setDocumentId] = useState();
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(25);
    const [nameProcedure, setNameProcedure] = useState('Doc_OutgoingDocumentsWork')

    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    const onChangeNameProcedureOnWork = () => {
        setNameProcedure("Doc_OutgoingDocumentsWork");
    }

    const onChangeNameProcedureOnSpent = () => {
        setNameProcedure("Doc_IncomingSpent");
    }

    const handlePrevPage = () => {
        if (pageNumber > 1) {
            setPageNumber(pageNumber - 1);
        }
    };

    const handleNextPage = () => {
        setPageNumber(pageNumber + 1);
    };

    const handlePageChange = (newPage) => {
        setPageNumber(newPage);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`https://localhost:7252/api/Document/${nameProcedure}/${pageNumber}/${pageSize}`);
                setDocuments(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [nameProcedure, pageNumber, pageSize]);

    return (
        <div className="centered-content  ml-4" style={{width:"70%"}}>
             <div style={{width:"70%"}}>
                <div className="my-4">
                    <div className="rounded-lg overflow-hidden shadow-lg">
                        <button  className="inline-block rounded bg-neutral-800 px-6 pb-2 pt-2.5 text-xs font-medium uppercase 
                                leading-normal text-neutral-50" onClick={()=>onChangeNameProcedureOnWork()}>В работе  </button>
                        <button className="ms-4 inline-block rounded bg-neutral-800 px-6 pb-2 pt-2.5 text-xs font-medium uppercase 
                                leading-normal text-neutral-50" onClick={()=>onChangeNameProcedureOnSpent()}>Отработанные \\</button>
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

export default OutgoingDocWork;
