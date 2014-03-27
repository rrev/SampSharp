﻿using System;
using GameMode.Definitions;

namespace GameMode.World
{
    public class GlobalObject : IDisposable
    {
        #region Fields

        public const int InvalidId = Misc.InvalidObjectId;

        #endregion

        #region Properties

        public virtual Vector Position 
        {
            get { return Native.GetObjectPos(ObjectId); }
            set { Native.SetObjectPos(ObjectId, value); }
        }

        public virtual Vector Rotation
        {
            get { return Native.GetObjectRot(ObjectId); }
            set { Native.SetObjectRot(ObjectId, value); }
        }

        public virtual bool IsMoving
        {
            get { return Native.IsObjectMoving(ObjectId); }
        }

        public virtual bool IsValid
        {
            get { return Native.IsValidObject(ObjectId); }
        }

        public virtual int ModelId { get; private set; }

        public virtual float DrawDistance { get; private set; }

        public virtual int ObjectId { get; private set; }

        #endregion

        #region Constructor

        public GlobalObject(int modelid, Vector position, Vector rotation, float drawDistance)
        {
            ModelId = modelid;
            DrawDistance = drawDistance;

            ObjectId = Native.CreateObject(modelid, position, rotation, drawDistance);
        }

        public GlobalObject(int modelid, Vector position, Vector rotation) : this(modelid, position, rotation, 0)
        {

        }

        #endregion

        #region Methods

        public virtual void AttachTo(Player player, Vector offset, Vector rotation)
        {
            Native.AttachObjectToPlayer(ObjectId, player.PlayerId, offset, rotation);
        }

        public virtual void AttachTo(Vehicle vehicle, Vector offset, Vector rotation)
        {
            Native.AttachObjectToVehicle(ObjectId, vehicle.VehicleId, offset, rotation);
        }

        public virtual void AttachTo(GlobalObject globalObject, Vector offset, Vector rotation)
        {
            Native.AttachObjectToVehicle(ObjectId, globalObject.ObjectId, offset, rotation);
        }

        public virtual int Move(Vector position, float speed, Vector rotation)
        {
            return Native.MoveObject(ObjectId, position, speed, rotation);
        }

        public virtual int Move(Vector position, float speed)
        {
            return Native.MoveObject(ObjectId, position.X, position.Y, position.Z, speed, -1000, -1000, -1000);
        }

        public virtual void Stop()
        {
            Native.StopObject(ObjectId);
        }

        public virtual void Edit(Player player)
        {
            Native.EditObject(player.PlayerId, ObjectId);
        }

        public static void Select(Player player)
        {
            Native.SelectObject(player.PlayerId);
        }

        public virtual void SetMaterial(int materialindex, int modelid, string txdname, string texturename, Color materialcolor)
        {
            Native.SetObjectMaterial(ObjectId, materialindex, modelid, txdname, texturename,
                materialcolor.GetColorValue(ColorFormat.ARGB));
        }

        public virtual void SetMaterialText(string text, int materialindex, ObjectMaterialSize materialsize,
            string fontface, int fontsize, bool bold, Color foreColor, Color backColor,
            ObjectMaterialTextAlign textalignment)
        {
            Native.SetObjectMaterialText(ObjectId, text, materialindex, (int) materialsize, fontface, fontsize, bold,
                foreColor.GetColorValue(ColorFormat.ARGB), backColor.GetColorValue(ColorFormat.ARGB),
                (int) textalignment);
        }

        public virtual void Dispose()
        {
            Native.DestroyObject(ObjectId);
        }

        #endregion

    }
}
