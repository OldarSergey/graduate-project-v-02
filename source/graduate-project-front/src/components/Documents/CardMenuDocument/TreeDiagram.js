import React from 'react';
import Tree from 'react-d3-tree';
import NodeLabelCard from './NodeLabelCard';
const TreeDiagram = ({ data, onNodeClick  }) => {
  // Создаем объект для хранения узлов дерева
  const treeNodes = {};

  // Формируем массив узлов дерева
  const treeData = [];

  // Проходим по данным и создаем узлы
  data.forEach(route => {
    const { userSender, userExecutor, ...attributes } = route;

    // Если узел отправителя уже есть, обновляем его атрибуты
    if (treeNodes[userSender]) {
      treeNodes[userSender].attributes = { ...treeNodes[userSender].attributes, ...attributes };
    } else {
      // Иначе создаем новый узел отправителя
      treeNodes[userSender] = { name: userSender, attributes: { ...attributes }, children: [] };
      // Добавляем его в корневой узел дерева
      treeData.push(treeNodes[userSender]);
    }

    // Если узел исполнителя уже есть, обновляем его атрибуты
    if (treeNodes[userExecutor]) {
      treeNodes[userExecutor].attributes = { ...treeNodes[userExecutor].attributes, ...attributes };
    } else {
      // Иначе создаем новый узел исполнителя
      treeNodes[userExecutor] = { name: userExecutor, attributes: { ...attributes }, children: [] };
      // Добавляем его в дочерние узлы отправителя
      treeNodes[userSender].children.push(treeNodes[userExecutor]);
    }
  });

  const handleNodeClick = (nodeDatum, userSender) => {
    onNodeClick(nodeDatum, userSender)
    console.log('пришло') // Передаем данные в родительский компонент
  };

  return (
    <div style={{ width: '100%', height: '400px' }}>
      <Tree
        data={treeData}
        pathFunc="step"
        orientation="vertical" // Ориентация дерева
        separation={{ siblings: 2, nonSiblings: 2 }}
        translate={{ x: 300, y: 50 }} // Смещение дерева
        renderCustomNodeElement={(props) => (
          <NodeLabelCard
            handleNodeClick={props.hierarchyPointNode.parent ?
              () => handleNodeClick(props.nodeDatum, props.hierarchyPointNode.parent.data.name) :
              () => handleNodeClick(props.nodeDatum, "Не указано")
            }
            nodeData={props.nodeDatum}
            hierarchyPointNode={props.hierarchyPointNode}
          />
        )}
        
        allowForeignObjects // Разрешение использования иностранных объектов
      />
    </div>
  );
};



export default TreeDiagram;
