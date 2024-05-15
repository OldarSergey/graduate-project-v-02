import React from 'react';

const NodeLabelCard = ({ nodeData, handleNodeClick }) => {
  return (
    <g  onClick={() => handleNodeClick()}>
      <rect 
        
        x="-80"
        y="-30" 
        width="160" 
        height="60" 
        rx="10" 
        fill="#0464B4" 
        stroke="#000000" 
        strokeWidth="1" />
      <text x="0" y="-10" textAnchor="middle" fontSize="14px" strokeWidth={0} fontWeight="normal" fill="#e9e9e9" style={{ fontWeight: 'normal' }}>{nodeData.name}</text>
      {/* Добавьте атрибут операции здесь */}
      <text x="0" y="10" textAnchor="middle" fontSize="12px" strokeWidth={0} fontWeight="normal" fill="#e9e9e9" style={{ fontWeight: 'normal' }}>{nodeData.attributes.operation}</text>
    </g>
  );
};

export default NodeLabelCard;
