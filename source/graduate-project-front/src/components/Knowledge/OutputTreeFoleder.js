import React, { useState, useEffect } from "react";
import axios from "axios";
import { FcFolder } from "react-icons/fc";
import TreeView from 'react-treeview';
import 'react-treeview/react-treeview.css';

function OutputTreeFolder() {
    const [instancesDoc, setInstancesDoc] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/KnowledgeBase`);
                setInstancesDoc(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, []);

    const renderTree = (nodes) => (
        <TreeView
            key={nodes.key_Group}
            nodeLabel={<span><FcFolder /> {nodes.name}</span>}
            defaultCollapsed={true}
        >
            {Array.isArray(nodes.children)
                ? nodes.children.map((node) => renderTree(node))
                : null}
        </TreeView>
    );

    return (
        <div className="mt-2">
            {instancesDoc.map((doc) => renderTree(doc))}
        </div>
    );
}

export default OutputTreeFolder;
