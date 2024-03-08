import axios from "axios";
import React, { useState, useEffect, useRef } from 'react';
import ModelOutputDoc from "../components/table/ModelOutputDoc";
import GetListInstancesDoc from "../components/GetInstances/GetListInstancesDoc";
import './OutgoingDocWork.css'


function OutgoingDocWork() {
    const [documents, setDocuments] = useState([]);
    const [documentId, setDocumentId] = useState();
    const [pageNumber, setPageNumber] = useState(1);
    const [loading, setLoading] = useState(false);
    const [hasMore, setHasMore] = useState(true);
    const [nameProcedure, setNameProcedure] = useState("Doc_OutgoingDocumentsWork")


    const pageSize = 25;
    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    const containerRef = useRef(null);

    const onChangeNameProcedureOnWork = () => {
        setNameProcedure('Doc_OutgoingDocumentsWork');
    }

    const onChangeNameProcedureOnSpent = () => {
        setNameProcedure('Doc_IncomingSpent');
    }


    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const response = await axios.get(`http://localhost:9902/api/Document/${nameProcedure}/${pageNumber}/${pageSize}`);
                if (response.data.length === 0)  {
                    setHasMore(false); 
                } else {
                    // Проверяем, изменилось ли значение nameProcedure
                    if (nameProcedure !== setNameProcedure.current) {
                        // Если значение nameProcedure изменилось, начинаем заново загружать данные
                        setDocuments(response.data);
                    } else {
                        // Если значение nameProcedure не изменилось, добавляем новые данные к текущему списку
                        setDocuments(prevDocuments => [...prevDocuments, ...response.data]);
                    }
                    // Обновляем текущее значение nameProcedure
                    setNameProcedure.current = nameProcedure;
                }
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
            setLoading(false);
        };
    
        fetchData();
    }, [nameProcedure, pageNumber, pageSize]);
    



    useEffect(() => {
        const container = containerRef.current;
        if (!container) return;
    
        const handleScroll = () => {
            const { scrollTop, clientHeight, scrollHeight } = container;
            if (scrollTop + clientHeight >= scrollHeight - 10 && !loading && hasMore) {
                setPageNumber(pageNumber => pageNumber + 1);
            }
        };
    
        container.addEventListener('scroll', handleScroll);
        return () => container.removeEventListener('scroll', handleScroll);
    }, [loading, hasMore]); 


    return (
        <div className="centered-content  ml-4" style={{ width: "70%" }}>
            <button  className="nav-button blue-button" activeClassName="active-button" onClick={()=>onChangeNameProcedureOnWork()}>В работе  </button>
            <button className="nav-button blue-button" activeClassName="active-button" onClick={()=>onChangeNameProcedureOnSpent()}>Отработанные \\</button>
                <div className="my-4" ref={containerRef} style={{ width: "70%", overflowY: 'auto', height: '50vh' }}>
                    <div className="rounded-lg shadow-lg">             
                        <ModelOutputDoc documents={documents} onDocumentClick={handleDocumentClick} />
                    </div>
                    {loading && <p>Loading...</p>}
                </div>
                
                
                <div className="my-4" style={{ width: "100%", overflowY: 'auto', height: '40vh' }}>
                    <div className="rounded-lg shadow-lg">
                        <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                    </div>
                </div>
        </div>
    );
}

export default OutgoingDocWork;
