import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import ModelOutputDoc from '../components/table/ModelOutputDoc';
import GetListInstancesDoc from '../components/GetInstances/GetListInstancesDoc';
import { NavLink } from 'react-router-dom';

function IncomingDocSpent() {
    const [documents, setDocuments] = useState([]);
    const [loading, setLoading] = useState(false);
    const [hasMore, setHasMore] = useState(true);
    const [pageNumber, setPageNumber] = useState(1);
        const [documentId, setDocumentId] = useState();
    const pageSize = 25;

    const containerRef = useRef(null);

    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const response = await axios.get(`https://176.106.132.3:9982/api/Document/Doc_IncomingSpent/${pageNumber}/${pageSize}`);
                if (response.data.length === 0) {
                    setHasMore(false); // Все данные загружены
                } else {
                    setDocuments(prevDocuments => [...prevDocuments, ...response.data]);
                }
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
            setLoading(false);
        };

        fetchData();
    }, [pageNumber, pageSize]);

    useEffect(() => {
        const container = containerRef.current;
        if (!container) return;
    
        const handleScroll = () => {
            const { scrollTop, clientHeight, scrollHeight } = container;
            if (scrollTop + clientHeight >= scrollHeight - 80 && !loading && hasMore) {
                setPageNumber(pageNumber => pageNumber + 1);
            }
        };
    
        container.addEventListener('scroll', handleScroll);
        return () => container.removeEventListener('scroll', handleScroll);
    }, [loading, hasMore]); 

    return (
        <div className="centered-content ml-4" style={{ width: "70%" }}>
            <div className='mt-5'>
                <NavLink to="../IncomingDocWork" className="nav-button blue-button" activeClassName="active-button">В работе</NavLink>
                <NavLink to="../IncomingDocSpent" className="nav-button blue-button" activeClassName="active-button">Отработанные</NavLink>
            </div>
            <div>
                <div className="my-4" ref={containerRef} style={{ width: "70%", overflowY: 'auto', height: '50vh' }}>
                    <div className=" shadow-lg">
                        <ModelOutputDoc documents={documents} onDocumentClick={handleDocumentClick} />
                    </div>
                    
                </div>
                
            </div>
            <div className="my-4 mt-5" style={{ width: "100%", overflowY: 'auto', height: '40vh' }}>
                        <div className="rounded-lg">
                            <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                        </div>
            </div>
            
        </div>
    );
}

export default IncomingDocSpent;
